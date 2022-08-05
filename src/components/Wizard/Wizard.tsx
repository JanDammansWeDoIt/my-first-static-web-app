import React, { useState } from "react";

import Link from "next/link";

import block from "../../models/block";
import ProjectBlocks from "./ProjectBlocks";
import ProjectDetails from "./ProjectDetails";
import ProjectSummary from "./ProjectSummary";

function Wizard() {
  const [step, setStep] = useState(1);
  const [projectName, setprojectName] = useState("");
  const [client, setClient] = useState("");
  const [hosting, setHosting] = useState(false);
  const [domain, setDomain] = useState(false);
  const [hostingUrl, setHostingUrl] = useState("");
  const [applicationType, setApplicationType] = useState<string[]>([]);
  const [project, setProject] = useState<block[]>([]);

  return (
    <div className="px-14 py-12">
      <Link href="/">
        <div className="flex gap-x-3 cursor-pointer">
          <img src="../../assets/icons/back.svg" alt="" className="w-4" />
          <p className="font-bold text-sm">Back to home</p>
        </div>
      </Link>
      {step === 1 ? (
        <ProjectDetails
          nextStep={setStep}
          projectName={projectName}
          setProjectName={setprojectName}
          client={client}
          setClient={setClient}
          hosting={hosting}
          setHosting={setHosting}
          domain={domain}
          setDomain={setDomain}
          hostingUrl={hostingUrl}
          setHostingUrl={setHostingUrl}
          applicationType={applicationType}
          setApplicationType={setApplicationType}
        />
      ) : null}
      {step === 2 ? (
        <ProjectBlocks
          nextStep={setStep}
          blocks={project}
          setProjectBlocks={setProject}
        />
      ) : null}
      {step === 3 ? (
        <ProjectSummary
          nextStep={setStep}
          project={projectName}
          client={client}
          hosting={hosting}
          hostingUrl={hostingUrl}
          applicationType={applicationType}
          blocks={project}
        />
      ) : null}
    </div>
  );
}

export default Wizard;
