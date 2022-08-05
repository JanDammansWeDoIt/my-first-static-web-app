import Block from "./block";
import Creator from "./creator";

type Project = {
  id: string;
  name: string;
  createdAt: Date;
  clientName: string;
  repositoryUrl: string;
  needHosting: boolean;
  hasDatabase: boolean;
  domain: string;
  type: string;
  lastModified: string;
  creator?: Creator | null;
  blocks: Block[];
};

export default Project;
