import { useState } from "react";
import api from "../api/api";

interface Props {
  projectId: string;
  onCreated: () => void;
}

export default function CreateTaskForm({ projectId, onCreated }: Props) {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await api.post("/Tasks", { title, description, projectId });
    setTitle("");
    setDescription("");
    onCreated();
  };

  return (
    <form onSubmit={handleSubmit}>
      <h4>Add New Task</h4>
      <input
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        placeholder="Title"
        required
      />
      <input
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        placeholder="Description"
        required
      />
      <button type="submit">Add Task</button>
    </form>
  );
}
