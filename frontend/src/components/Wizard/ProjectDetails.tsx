import React, { Dispatch, SetStateAction } from "react";

import Link from "next/link";

type ProjectDetailsProps = {
  nextStep: Dispatch<SetStateAction<number>>;
  projectName: string;
  setProjectName: Dispatch<SetStateAction<string>>;
  client: string;
  setClient: Dispatch<SetStateAction<string>>;
  hosting: boolean;
  setHosting: Dispatch<SetStateAction<boolean>>;
  domain: boolean;
  setDomain: Dispatch<SetStateAction<boolean>>;
  hostingUrl: string;
  setHostingUrl: Dispatch<SetStateAction<string>>;
  applicationType: string[];
  setApplicationType: Dispatch<SetStateAction<Array<string>>>;
};

function ProjectDetails({
  nextStep,
  projectName,
  setProjectName,
  client,
  setClient,
  hosting,
  setHosting,
  domain,
  setDomain,
  hostingUrl,
  setHostingUrl,
  applicationType,
  setApplicationType,
}: ProjectDetailsProps) {
  const addType = (type: string) => {
    (document.getElementById("webapp") as HTMLInputElement)?.setCustomValidity(
      ""
    );
    if (!applicationType.includes(type)) {
      setApplicationType([...applicationType, type]);
    } else {
      setApplicationType([
        ...applicationType.filter((value) => {
          return value !== type;
        }),
      ]);
    }
  };

  return (
    <div>
      <form onSubmit={() => nextStep(2)}>
        <div className="mx-20 mt-14">
          <h1 className="text-black text-lg">
            1. Let&apos;s create a new project
          </h1>
          <div className="mt-10">
            <p className="text-black text-base font-semibold">
              Project details
            </p>
            <div className="flex mt-6 w-full">
              <input
                type="text"
                onChange={(e) => setProjectName(e.target.value)}
                value={projectName}
                placeholder="Project Name"
                id="searchbar"
                className="drop-shadow-black w-6/12 mr-8 pl-8 pr-10 py-4 rounded-full text-black focus:border-none font-bold placeholder-shown:font-bold placeholder-gray-600 text-xxs outline-none"
                required
              />
              <input
                type="text"
                onChange={(e) => setClient(e.target.value)}
                value={client}
                placeholder="Client"
                id="searchbar"
                className="drop-shadow-black w-4/12 pl-8 pr-10 py-4 rounded-full text-black focus:border-none font-bold placeholder-shown:font-bold placeholder-gray-600 text-xxs outline-none"
                required
              />
            </div>
          </div>

          <div className="mt-12">
            <p className="text-black text-base font-semibold">
              Does this application need hosting?
            </p>
            <div className="flex mt-6 w-full">
              <div className="flex">
                <label
                  htmlFor="yesHosting"
                  className="text-black font-semibold text-xxs flex"
                >
                  <input
                    type="radio"
                    id="yesHosting"
                    onClick={() => setHosting(true)}
                    checked={hosting}
                    name="hosting"
                    value="yesHosting"
                    className="bg-white drop-shadow-hardBlack mr-2"
                  />
                  <p className="-mt-0.5 text-black font-semibold">yes</p>
                </label>
              </div>
              <div className="flex ml-5">
                <label
                  htmlFor="noHosting"
                  className="text-black font-semibold text-xxs ml-2 flex"
                >
                  <input
                    type="radio"
                    id="noHosting"
                    onClick={() => setHosting(false)}
                    checked={!hosting}
                    name="hosting"
                    value="noHosting"
                    className="bg-white drop-shadow-hardBlack mr-2"
                  />
                  <p className="-mt-0.5 text-black font-semibold">no</p>
                </label>
              </div>
            </div>
            <div
              className={
                domain
                  ? "flex mt-2 items-center"
                  : "flex mt-6 mb-14 items-center"
              }
            >
              <p className="text-black text-xxs font-semibold mr-7">
                Do you already have a website domain?
              </p>
              <div className="flex">
                <label
                  htmlFor="yesDomain"
                  className="text-black font-semibold text-xxs flex"
                >
                  <input
                    type="radio"
                    id="yesDomain"
                    onClick={() => setDomain(true)}
                    checked={domain}
                    name="domain"
                    value="yesDomain"
                    className="bg-white drop-shadow-hardBlack mr-2"
                  />
                  <p className="-mt-0.5 text-black font-semibold">yes</p>
                </label>
              </div>
              <div className="flex ml-5">
                <label
                  htmlFor="noDomain"
                  className="text-black font-semibold text-xxs ml-2 flex"
                >
                  <input
                    type="radio"
                    id="noDomain"
                    onClick={() => setDomain(false)}
                    checked={!domain}
                    name="domain"
                    value="noDomain"
                    className="bg-white drop-shadow-hardBlack mr-2"
                  />
                  <p className="-mt-0.5 text-black font-semibold">no</p>
                </label>
              </div>
              <input
                type="text"
                onChange={(e) => setHostingUrl(e.target.value)}
                value={hostingUrl}
                placeholder="Website domain"
                id="searchbar"
                className={
                  domain
                    ? "drop-shadow-black ml-7 w-80 pl-8 pr-10 py-4 rounded-full text-black focus:border-none font-bold placeholder-shown:font-bold placeholder-gray-600 text-xxs outline-none"
                    : "hidden"
                }
              />
            </div>
          </div>
          <div className="mt-10">
            <p className="text-black text-base font-semibold">
              Application type
            </p>
            <div className="flex mt-6 w-full gap-x-16">
              <label htmlFor="webapp" className="flex items-center">
                <input
                  type="checkbox"
                  onChange={() => {
                    addType("Web Application");
                  }}
                  checked={applicationType.includes("Web Application")}
                  id="webapp"
                  name="application"
                  value="webapp"
                  className="mr-2"
                  required={applicationType.length === 0}
                  onInvalid={(e: React.ChangeEvent<HTMLInputElement>) => {
                    if (applicationType.length === 0) {
                      e.target.setCustomValidity(
                        "Please fill in one of the boxes"
                      );
                    } else {
                      e.target.setCustomValidity("");
                    }
                  }}
                />
                <span className="text-black font-semibold text-xs">
                  Web Application
                </span>
              </label>
              <label htmlFor="website" className="flex items-center">
                <input
                  type="checkbox"
                  onChange={() => {
                    addType("Website");
                  }}
                  checked={applicationType.includes("Website")}
                  id="website"
                  name="application"
                  value="website"
                  className="mr-2"
                  required={applicationType.length === 0}
                />
                <span className="text-black font-semibold text-xs">
                  Website
                </span>
              </label>
              <label htmlFor="mobile" className="flex items-center">
                <input
                  type="checkbox"
                  onChange={() => {
                    addType("Mobile Application");
                  }}
                  checked={applicationType.includes("Mobile Application")}
                  id="mobile"
                  name="application"
                  value="mobile"
                  className="mr-2"
                  required={applicationType.length === 0}
                />
                <span className="text-black font-semibold text-xs">
                  Mobile Application
                </span>
              </label>
              <label htmlFor="custom" className="flex items-center">
                <input
                  type="checkbox"
                  onChange={() => {
                    addType("Custom Development");
                  }}
                  checked={applicationType.includes("Custom Development")}
                  id="custom"
                  name="application"
                  value="custom"
                  className="mr-2"
                  required={applicationType.length === 0}
                />
                <span className="text-black font-semibold text-xs">
                  Custom Development
                </span>
              </label>
            </div>
          </div>
        </div>
        <div className="buttons float-right mt-20 mr-10">
          <div className="flex gap-x-4">
            <Link href="/dashboard" passHref>
              <button
                type="button"
                className="py-3 rounded-full text-white focus:border-none font-bold bg-grey w-36 outline-none drop-shadow-red hover:opacity-90 text-sm"
              >
                Back
              </button>
            </Link>
            <button
              type="submit"
              className="py-3 rounded-full text-white focus:border-none font-bold bg-nextgen w-48 outline-none drop-shadow-red hover:opacity-90 text-sm"
            >
              Next
            </button>
          </div>
        </div>
      </form>
    </div>
  );
}

export default ProjectDetails;
