type CreateProjectRequest = {
  Name: string;
  CreatedAt: Date;
  ClientName: string;
  RepositoryUrl: string;
  NeedHosting: boolean;
  HasDatabase: boolean;
  Domain: string;
  Types: string[];
  LastModified: Date;
  CreatorId: string;
  Blocks: string[];
};

export default CreateProjectRequest;
