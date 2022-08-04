import React, { Dispatch, SetStateAction, useState } from "react";

import axios, { AxiosError } from "axios";
import { useRouter } from "next/router";

import block from "../../models/block";
import CreateProjectRequest from "../../models/CreateProjectRequest";
import NextgenResponse from "../../models/NextgenResponse";

type ProjectSummaryProps = {
  nextStep: Dispatch<SetStateAction<number>>;
  project: string;
  client: string;
  hosting: boolean;
  hostingUrl: string;
  applicationType: string[];
  blocks: block[];
};

function ProjectSummary({
  nextStep,
  project,
  client,
  hosting,
  hostingUrl,
  applicationType,
  blocks,
}: ProjectSummaryProps) {
  const [errors, setErrors] = useState<string[]>([]);
  const router = useRouter();
  function createProject() {
    const guidOfBlocks: string[] = [];
    blocks.forEach((item) => {
      guidOfBlocks.push(item.id.toString());
    });
    const request: CreateProjectRequest = {
      Name: project,
      CreatedAt: new Date(),
      ClientName: client,
      RepositoryUrl: "emptyUrl.be",
      NeedHosting: hosting,
      HasDatabase: false,
      Domain: hostingUrl,
      Types: applicationType,
      LastModified: new Date(),
      CreatorId: "ed1deefc-d206-4d55-8177-d631a26d1a6c",
      Blocks: guidOfBlocks,
    };
    axios
      .post(`${process.env.NEXT_PUBLIC_BASE_URL}/Projects`, request)
      .then(() => {
        router.push("/");
      })
      .catch((error: AxiosError<NextgenResponse>) => {
        if (error.response) {
          // Request made and server responded
          setErrors(error.response.data.errorMessages);
        } else if (error.request) {
          // The request was made but no response was received
          // eslint-disable-next-line no-console
          console.log(error.request);
        } else {
          // Something happened in setting up the request that triggered an Error
          // eslint-disable-next-line no-console
          console.log("Error", error.message);
        }
      });
  }

  return (
    <div>
      <div className="w-9/12 mt-14 mx-auto">
        <h1 className="text-black text-lg">
          3. Let&apos;s create a new project
        </h1>
        <div className="mt-8">
          <p className="text-black text-base font-semibold">Project summary</p>
          <div className="flex gap-x-20 mt-4 bg-nextgen w-full h-96 rounded-2xl drop-shadow-red pt-10 px-12">
            <div className="">
              <h3 className="text-white font-bold">Project Type</h3>
              <div className="">
                {applicationType.map((item) => (
                  <p className="text-white text-sm mt-2" key={item}>
                    {item}
                  </p>
                ))}
              </div>

              <div className="flex gap-x-10 mt-10 w-max">
                <div>
                  <h3 className="text-white font-bold">Project Name</h3>
                  <p className="text-white text-sm mt-2">{project}</p>
                </div>
                <div>
                  <h3 className="text-white font-bold">Client</h3>
                  <p className="text-white text-sm mt-2">{client}</p>
                </div>
              </div>
              <h3 className="text-white font-bold mt-10">Hosting</h3>
              <p className="text-white text-sm mt-2">
                {hosting ? `yes -  ${hostingUrl}` : "no"}
              </p>
            </div>
            <div>
              <h3 className="text-white font-bold">Project Blocks</h3>
              <div className="flex flex-wrap gap-x-4 gap-y-3 w-11/12 mt-3">
                {blocks.map((item) => (
                  <p
                    className="text-red bg-white font-bold text-xs px-12 py-2 rounded-full w-min"
                    key={item.id.toString()}
                  >
                    {item.name}
                  </p>
                ))}
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="my-6 w-9/12 mx-auto flex flex-col justify-end">
        {errors.map((error) => (
          <p key={error} className="text-right text-red">
            * {error}
          </p>
        ))}
      </div>
      <div className="buttons w-9/12 mx-auto flex justify-end">
        <div className="flex gap-x-4">
          <button
            type="button"
            onClick={() => nextStep(2)}
            className="py-3 rounded-full text-white focus:border-none font-bold bg-grey w-36 outline-none drop-shadow-red hover:opacity-90 text-sm"
          >
            Back
          </button>
          <button
            onClick={createProject}
            type="button"
            className="py-3 rounded-full text-white focus:border-none font-bold bg-nextgen w-48 outline-none drop-shadow-red hover:opacity-90 text-sm"
          >
            Finish
          </button>
        </div>
      </div>
    </div>
  );
}

export default ProjectSummary;
