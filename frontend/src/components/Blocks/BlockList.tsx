import React, { ReactNode } from "react";

import { List } from "@we-do-it/react-component-library/";

import Block from "../../models/block";

export interface BlockListProps {
  blocks: Block[];
}
const removeBlock = () => {
  // TODO: Implement remove function
};

const editBlock = () => {
  // TODO: Implement edit function
};
const BlockList = ({ blocks }: BlockListProps) => {
  return (
    <div className="w-full flex justify-center">
      <List
        data={blocks}
        columnWidth={["20%", "25%", "18%", "37%"]}
        action={{
          remove: () => removeBlock(),
          edit: () => editBlock(),
        }}
        customValueField={{
          // eslint-disable-next-line react/display-name
          wrapperComponent: (children: ReactNode) => (
            <div className="flex justify-between content-center bg-commandGray w-60 rounded-full px-2 py-1 text-xxs">
              <p className="text-black font-bold overflow-ellipsis overflow-hidden pl-2 whitespace-nowrap w-10/12">
                {children}
              </p>
              <button type="button" className="w-1/12">
                <img src="../assets/icons/copy.svg" alt="Copy command" />
              </button>
            </div>
          ),
          column: 3,
        }}
      />
    </div>
  );
};

export default BlockList;
