import api from "../api/api";
import type { Task } from "../models/task";

interface Props {
  tasks: Task[];
  onTaskCompleted: () => void;
}

export default function TaskList({ tasks, onTaskCompleted }: Props) {
  const completeTask = async (id: string) => {
    try {
      await api.put(`/Tasks/${id}/complete`);
      onTaskCompleted();
    } catch (error) {
      console.error("Failed to complete task:", error);
      alert("❌ Erreur lors de la mise à jour");
    }
  };

  return (
    <div className="grid-container">
      {tasks.map((t) => (
        <div className="card" key={t.Id}>
          {/* Title */}
          <div className="title">{t.Title}</div>

          {/* Icon */}
          <div className="icon">
            {t.Status === 2 ? (
              <i className="fa-solid fa-circle-check"></i>
            ) : (
              <i className="fa-regular fa-circle"></i>
            )}
          </div>

          {/* Content : bouton + statut + description */}
          <div className="content">
            <div className="status-line">
              {t.Status !== 2 && (
                <button onClick={() => completeTask(t.Id)}>✔</button>
              )}
              <span>{t.Status === 2 ? "Done ✅" : "Todo ⏳"}</span>
            </div>
            <p className="description">{t.Description}</p>
          </div>
        </div>
      ))}
    </div>
  );
}
