import React, { useEffect, useState } from "react";

import axios from "axios";

import Project from "../../models/project";
import DatePicker from "../DatePicker/DatePicker";
import { Header } from "../Header";
import FilterButton from "./FilterButton";
import ProjectList from "./ProjectList";

function Dashboard() {
  const [selectedStatus, setSelectedStatus] = useState("Pending");
  const [projectData, setProjectData] = useState<Project[]>([]);

  useEffect(() => {
    function fetchData() {
      axios
        .get(`${process.env.NEXT_PUBLIC_BASE_URL}/Projects`)
        .then((response) => {
          setProjectData(response.data.projects);
        })
        .catch((error) => {
          if (error.response) {
            // Request made and server responded
            console.log(error.response);
          } else if (error.request) {
            // The request was made but no response was received
            console.log(error.request);
          } else {
            // Something happened in setting up the request that triggered an Error
            console.log("Error", error.message);
          }
        });
    }
    fetchData();
  }, []);

  const statuses: string[] = [
    "Pending",
    "Accepted",
    "Declined",
    "All Projects",
  ];

  return (
    // dashboard
    <div className="h-screen w-full py-10 px-14">
      <Header title="Dashboard" />
      {/* filters */}
      <div className="flex mb-4 justify-between">
        <div className="flex gap-7">
          {statuses.map((status) => {
            return (
              <FilterButton
                key={status}
                buttonText={status}
                selected={selectedStatus}
                setSelected={setSelectedStatus}
              />
            );
          })}
        </div>
        <DatePicker />
      </div>
      {projectData?.length > 0 ? (
        <ProjectList projects={projectData} />
      ) : (
        <div />
      )}
    </div>
  );
}

export default Dashboard;
