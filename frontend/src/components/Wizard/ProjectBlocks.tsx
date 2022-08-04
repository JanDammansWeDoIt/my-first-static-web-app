import React, { Dispatch, SetStateAction, useState } from "react";

import { Guid } from "guid-typescript";

import block from "../../models/block";
import ProjectBlock from "./ProjectBlock";

type ProjectBlocksProps = {
  nextStep: Dispatch<SetStateAction<number>>;
  blocks: block[];
  setProjectBlocks: Dispatch<SetStateAction<block[]>>;
};

function ProjectBlocks({
  nextStep,
  blocks,
  setProjectBlocks,
}: ProjectBlocksProps) {
  const [funcTitle, setFuncTitle] = useState("Login");
  const lorem =
    "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, seddiam nonumy eirmod tempor invidunt ut labore et dolore magnaaliquyam erat, sed diam voluptua. At vero eos et accusam etjusto duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem";

  const [funcDo, setFuncDo] = useState(lorem);
  const [funcWork, setFuncWork] = useState(lorem);
  const [funcCost, setFuncCost] = useState(lorem);
  return (
    <div>
      <div className="mx-20 mt-14">
        <h1 className="text-black text-lg">
          2. Let&apos;s create a new project
        </h1>
        <div className="mt-8">
          <p className="text-black text-base font-semibold">Project Blocks</p>
          <div className="flex w-full mt-4 gap-x-10">
            <div className="bg-nextgen w-5/12 h-96 rounded-2xl drop-shadow-red pt-5">
              <div className="h-80 scrollbar-thin scrollbar-thumb-white scrollbar-track-red rounded scrollbar-thumb-rounded-full scrollbar-track-rounded-full mr-5">
                <ProjectBlock
                  id={Guid.parse("0f448820-4ee6-4d80-b633-0e987a4d10fa")}
                  name="Mail"
                  setTitle={setFuncTitle}
                  funcDo={lorem}
                  setDo={setFuncDo}
                  work={lorem}
                  setWork={setFuncWork}
                  cost={lorem}
                  setCost={setFuncCost}
                  projectBlocks={blocks}
                  setProjectBlocks={setProjectBlocks}
                />
                <ProjectBlock
                  id={Guid.parse("0f448820-4ee6-4d80-b633-0e987a4d10fb")}
                  name="Mail"
                  setTitle={setFuncTitle}
                  funcDo={lorem}
                  setDo={setFuncDo}
                  work={lorem}
                  setWork={setFuncWork}
                  cost={lorem}
                  setCost={setFuncCost}
                  projectBlocks={blocks}
                  setProjectBlocks={setProjectBlocks}
                />
              </div>
            </div>
            <div className="bg-white w-7/12 h-96 rounded-2xl drop-shadow-black pl-14 py-10">
              <div className="h-80 scrollbar-thin scrollbar-thumb-black scrollbar-track-gray-200 rounded scrollbar-thumb-rounded-full scrollbar-track-rounded-full mr-5">
                <h2 className="text-red text-lg">{funcTitle}</h2>
                <h3 className="font-semibold text-sm mt-4">
                  What does this do?
                </h3>
                <p className="text-xs mt-4 w-10/12">{funcDo}</p>
                <h3 className="font-semibold text-sm mt-4">How does it work</h3>
                <p className="text-xs mt-4 w-10/12">{funcWork}</p>
                <h3 className="font-semibold text-sm mt-4">
                  How much does it cost?
                </h3>
                <p className="text-xs mt-4 w-10/12">{funcCost}</p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="buttons float-right mt-12 mr-10">
        <div className="flex gap-x-4">
          <button
            type="button"
            onClick={() => nextStep(1)}
            className="py-3 rounded-full text-white focus:border-none font-bold bg-grey w-36 outline-none drop-shadow-red hover:opacity-90 text-sm"
          >
            Back
          </button>
          <button
            type="button"
            onClick={() => nextStep(3)}
            className="py-3 rounded-full text-white focus:border-none font-bold bg-nextgen w-48 outline-none drop-shadow-red hover:opacity-90 text-sm"
          >
            Next
          </button>
        </div>
      </div>
    </div>
  );
}

export default ProjectBlocks;
