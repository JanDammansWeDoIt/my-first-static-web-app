import React from "react";

import { Guid } from "guid-typescript";

import Block from "../../models/block";
import { Header } from "../Header";
import BlockList from "./BlockList";

export const OurBlocks = () => {
  const data: Block[] = [
    {
      id: Guid.create(),
      name: "TestBlock",
      command: "Test",
    },
    {
      id: Guid.create(),
      name: "EmailBlock",
      command: "dotnet...",
    },
    {
      id: Guid.create(),
      name: "TestBlock",
      command:
        "/usr/bin/install [- c DirectoryA] [- f DirectoryB] [- i] [- m] [- M Mode] [- O Owner] [- G Group] [- S] [- n DirectoryC] [- o] [- s] File [Directory ... ]",
    },
  ];

  return (
    <div className="h-screen w-full py-10 px-14">
      <Header title="Our Blocks" />
      <BlockList blocks={data} />
    </div>
  );
};
