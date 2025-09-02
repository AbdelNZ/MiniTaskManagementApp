import { useState, useEffect } from "react";
import TaskList from "./components/TaskList";
import CreateTaskForm from "./components/CreateTaskForm";
import CreateProjectForm from "./components/CreateProjectForm";
import ProjectSelector from "./components/ProjectSelector";
import "./App.css";
import { getProjects } from "./api/projects";
import type { Project } from "./models/project";
import api from "./api/api";
import type { Task } from "./models/task";

function App() {
  const [projectId, setProjectId] = useState<string>("");
  const [projects, setProjects] = useState<Project[]>([]);
  const [tasks, setTasks] = useState<Task[]>([]);
  const [refreshProjects, setRefreshProjects] = useState({});
  const [refreshTasks, setRefreshTasks] = useState({});

  // 👇 états pour afficher ou non les formulaires
  const [showCreateProject, setShowCreateProject] = useState(false);
  const [showCreateTask, setShowCreateTask] = useState(false);

  useEffect(() => {
    const loadProjects = async () => {
      const data = await getProjects();
      setProjects(data);
    };
    loadProjects();
  }, [refreshProjects]);

  useEffect(() => {
    if (!projectId) {
      setTasks([]);
      return;
    }
    const loadTasks = async () => {
      const res = await api.get(`/Tasks/project/${projectId}`);
      setTasks(res.data);
    };
    loadTasks();
  }, [projectId, refreshTasks]);

  return (
    <div className="app-container">
      <h1>Task Management</h1>
      <div className="columns">
        <div className="column">
          {/* Bouton pour afficher le form project */}
          <button onClick={() => setShowCreateProject((prev) => !prev)}>
            {showCreateProject ? "✖ Cancel" : "➕ Create New Project"}
          </button>

          {/* Formulaire projet affiché seulement si showCreateProject = true */}
          {showCreateProject && (
            <CreateProjectForm
              onCreated={() => {
                setRefreshProjects({});
                setShowCreateProject(false); // refermer après création
              }}
            />
          )}

          <ProjectSelector projects={projects} onSelect={setProjectId} />
        </div>

        <div className="column">
          {projectId && (
            <>
              {/* Bouton pour afficher le form task */}
              <button onClick={() => setShowCreateTask((prev) => !prev)}>
                {showCreateTask ? "✖ Cancel" : "➕ Add New Task"}
              </button>

              {/* Formulaire task affiché seulement si showCreateTask = true */}
              {showCreateTask && (
                <CreateTaskForm
                  projectId={projectId}
                  onCreated={() => {
                    setRefreshTasks({});
                    setShowCreateTask(false); // refermer après création
                  }}
                />
              )}

              <TaskList
                tasks={tasks}
                onTaskCompleted={() => setRefreshTasks({})}
              />
            </>
          )}
        </div>
      </div>
    </div>
  );
}

export default App;
