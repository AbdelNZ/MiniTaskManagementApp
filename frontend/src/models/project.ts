import type { Task } from "./task";

export interface Project {
    Id: string;
    Name: string;
    Description: string;
    Tasks: Task[];
}
