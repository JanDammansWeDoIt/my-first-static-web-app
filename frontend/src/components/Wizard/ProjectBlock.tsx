import React, { Dispatch, SetStateAction } from "react";

import { Guid } from "guid-typescript";

import block from "../../models/block";

type ProjectBlocksProps = {
  id: Guid;
  name: string;
  setTitle: Dispatch<SetStateAction<string>>;
  funcDo: string;
  setDo: Dispatch<SetStateAction<string>>;
  work: string;
  setWork: Dispatch<SetStateAction<string>>;
  cost: string;
  setCost: Dispatch<SetStateAction<string>>;
  projectBlocks: block[];
  setProjectBlocks: Dispatch<SetStateAction<block[]>>;
};

function ProjectBlock({
  id,
  name,
  setTitle,
  funcDo,
  setDo,
  work,
  setWork,
  cost,
  setCost,
  projectBlocks,
  setProjectBlocks,
}: ProjectBlocksProps) {
  function setInfo() {
    setTitle(name);
    setDo(funcDo);
    setWork(work);
    setCost(cost);

    if (!projectBlocks.some((projectBlock) => projectBlock.id.equals(id))) {
      setProjectBlocks([...projectBlocks, { id, name, command: "" }]);
    } else {
      setProjectBlocks([
        ...projectBlocks.filter((projectBlock) => {
          return !projectBlock.id.equals(id);
        }),
      ]);
    }
  }

  return (
    <div>
      <div className="flex items-center mx-8 justify-between w-8/12 mt-6">
        <div className="flex items-center gap-x-3">
          <input
            type="checkbox"
            onChange={() => setInfo()}
            defaultChecked={projectBlocks.some((projectBlock) =>
              projectBlock.id.equals(id)
            )}
            id="mobile"
            name="application"
            value="mobile"
          />
          <p className="text-white font-semibold text-sm">{name}</p>
        </div>
        <button type="button" onClick={() => setInfo()}>
          <img
            src="../assets/icons/info.svg"
            alt=""
            className="cursor-pointer"
          />
        </button>
      </div>
      <div className="bg-white rounded-full w-8/12 h-0.5 ml-8 mt-4" />
    </div>
  );
}

export default ProjectBlock;
