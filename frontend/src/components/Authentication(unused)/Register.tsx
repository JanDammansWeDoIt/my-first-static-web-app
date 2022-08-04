import React from "react";

import Link from "next/link";

function Register() {
  return (
    <div className="h-screen pr-32 xl:pr-52 2xl:pr-88">
      <div className="content flex h-full justify-between gap-x-16">
        <img
          className="h-9/10 drop-shadow-red"
          src="../assets/images/nextgenBG.svg"
          alt=""
        />
        <div className="form pt-40 2xl:pt-60">
          <h2 className="text-red text-2xl">Register to</h2>
          <h1 className="text-red text-5xl -mt-3">NextGen</h1>
          <div className="inputfield relative mt-8">
            <div className="icon absolute z-10 mt-0.5">
              <img
                className="w-3 mt-4 ml-7"
                src="../assets/icons/username.svg"
                alt=""
              />
            </div>
            <input
              type="text"
              placeholder="E-mailadres"
              className="drop-shadow-black pl-16 pr-10 py-4 rounded-full text-grey focus:border-none font-bold text-xs placeholder-grey w-88 outline-none"
            />
          </div>
          <div className="inputfield relative mt-6">
            <div className="icon absolute z-10 mt-0.5">
              <img
                className="w-3 mt-4 ml-7"
                src="../assets/icons/password.svg"
                alt=""
              />
            </div>
            <input
              type="password"
              placeholder="Password"
              className="drop-shadow-black pl-16 pr-10 py-4 rounded-full text-grey focus:border-none font-bold text-xs placeholder-grey w-88 outline-none"
            />
          </div>
          <div className="inputfield relative mt-6">
            <div className="icon absolute z-10 mt-0.5">
              <img
                className="w-3 mt-4 ml-7"
                src="../assets/icons/password.svg"
                alt=""
              />
            </div>
            <input
              type="password"
              placeholder="Confirm Password"
              className="drop-shadow-black pl-16 pr-10 py-4 rounded-full text-grey focus:border-none font-bold text-xs placeholder-grey w-88 outline-none"
            />
          </div>
          <div className="flex mt-5 justify-end">
            {/* eslint-disable-next-line @next/next/no-html-link-for-pages */}
            <a href="/api/auth/logout">
              <button
                type="button"
                className="py-3 rounded-full text-white focus:border-none font-bold bg-nextgen w-56 outline-none drop-shadow-red hover:opacity-90"
              >
                Register
              </button>
            </a>
          </div>
        </div>
      </div>
      <div className="bottom flex -mt-10 px-10 justify-between xl:pr-16">
        <p className="text-red font-bold text-xs">Made by We do IT</p>
        <Link href="/login">
          <button type="button" className="text-red font-semibold text-xs">
            Already have an account?{" "}
            <span className="font-bold">Login here!</span>
          </button>
        </Link>
      </div>
    </div>
  );
}

export default Register;
