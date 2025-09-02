export interface Task {
  Id: string;
  Title: string;
  Description: string;
  Status: number; // 0=Todo, 1=InProgress, 2=Done
  // projectId: string;
}
