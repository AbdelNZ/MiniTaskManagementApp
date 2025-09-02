import api from './api';
import type { Project } from '../models/project';

export async function createProject(name:string, description:string): Promise<Project> {
   const res = await  api.post<Project>("/Projects", {name, description});
   return res.data;
}

export async function getProjects(): Promise<Project[]>
{
    const res = await api.get<Project[]>("/Projects");
    return res.data;
}