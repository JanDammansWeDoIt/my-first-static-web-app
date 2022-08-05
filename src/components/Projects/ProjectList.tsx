import React, { ReactNode } from "react";

import { List } from "@we-do-it/react-component-library/";

import Project from "../../models/project";
import Status from "../../models/Status";

export interface ProjectListProps {
  projects: Project[];
}

interface ProjectValuesToBeShownInList {
  id: string;
  project: string;
  client: string;
  date: string;
  status: Status;
}

const ProjectList = ({ projects }: ProjectListProps) => {
  const ProjectValuesToBeShownInList: ProjectValuesToBeShownInList[] =
    projects.map((project) => ({
      id: project.id,
      project: project.name,
      client: project.clientName,
      date: new Date(project.createdAt)
        .toISOString()
        .replace(/T.*/, "")
        .split("-")
        .reverse()
        .join("-"),
      status: Status.Pending,
    }));

  const setStatusColor = (status?: Status) => {
    if (status === Status.Pending) {
      return "bg-statusYellow py-1 w-min rounded-full text-white px-5";
    }
    if (status === Status.Accepted) {
      return "bg-statusGreen py-1 w-min rounded-full text-white px-5";
    }

    if (status === Status.Declined) {
      return "bg-statusRed py-1 w-min rounded-full text-white px-5";
    }
    return "py-1 w-min rounded-full text-white px-5";
  };

  const removeProject = () => {
    // TODO: Implement remove function
  };

  const editProject = () => {
    // TODO: Implement remove function
  };

  return (
    <div className="w-full flex justify-center">
      <List
        data={ProjectValuesToBeShownInList}
        columnWidth={["18.33%", "24%", "22%", "18%", "17.67%"]}
        action={{
          remove: () => removeProject(),
          edit: () => editProject(),
        }}
        expand={{
          data: projects,
          title: projects.map((project) => project.type),
          // eslint-disable-next-line react/display-name
          component: (_: ProjectValuesToBeShownInList, project?: Project) => (
            <div>
              <p className="font-semibold text-black text-base mb-4">Blocks</p>
              <div className="flex">
                {project?.blocks.map((block) => {
                  return (
                    <p
                      key={project?.id}
                      className="bg-white drop-shadow-black mr-4  px-8 rounded-full py-2 w-max font-semibold text-xs"
                    >
                      {block.name}
                    </p>
                  );
                })}
              </div>
            </div>
          ),
        }}
        customValueField={{
          column: 4,
          // eslint-disable-next-line react/display-name
          wrapperComponent: (
            _children: ReactNode,
            item?: ProjectValuesToBeShownInList
          ) => <div className={setStatusColor(item?.status)}>Pending</div>,
        }}
      />
    </div>
  );
};

export default ProjectList;
