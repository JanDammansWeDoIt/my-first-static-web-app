import React from "react";

import Link from "next/link";

function Welcome() {
  return (
    <div className="h-screen w-full pt-64 text-center">
      <h1 className="text-5xl text-red">Welcome!</h1>
      <h1 className="text-xl text-black mb-5">
        Press the button to create a new project.
      </h1>
      <Link href="/createProject">
        <button
          type="button"
          className="py-3 rounded-full text-white focus:border-none font-bold bg-nextgen w-56 outline-none drop-shadow-red hover:opacity-90"
        >
          New Project
        </button>
      </Link>
    </div>
  );
}

export default Welcome;
