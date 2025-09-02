import { useState } from "react";
import { createProject } from "../api/projects";

interface Props {
  onCreated: () => void;
}

export default function CreateProjectForm({ onCreated }: Props) {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await createProject(name, description);
    setName("");
    setDescription("");
    onCreated();
  };

  return (
    <form onSubmit={handleSubmit}>
      <h3>Create New Project</h3>
      <input
        value={name}
        onChange={(e) => setName(e.target.value)}
        placeholder="Project Name"
        required
      />
      <input
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        placeholder="Project Description"
        required
      />
      <button type="submit">Create Project</button>
    </form>
  );
}
