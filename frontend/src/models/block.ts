import { Guid } from "guid-typescript";

type Block = {
  id: Guid;
  name: string;
  command: string;
};

export default Block;
