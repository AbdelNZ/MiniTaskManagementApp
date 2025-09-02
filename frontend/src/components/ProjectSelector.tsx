import type { Project } from "../models/project";

interface Props {
  projects: Project[];
  onSelect: (projectId: string) => void;
}

export default function ProjectSelector({ projects, onSelect }: Props) {
  return (
    <div className="project-selector">
      <h3>Select Project</h3>
      <select onChange={(e) => onSelect(e.target.value)} defaultValue="">
        <option value="" disabled>
          Select a project
        </option>
        {projects.map((p) => (
          <option key={p.Id} value={p.Id}>
            {p.Name}
          </option>
        ))}
      </select>
    </div>
  );
}
