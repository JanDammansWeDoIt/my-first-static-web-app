import React from "react";

import Link from "next/link";

function Login() {
  return (
    <div className="h-screen pr-32 xl:pr-52 2xl:pr-88">
      <div className="content flex h-full justify-between gap-x-16">
        <img
          className="h-9/10 drop-shadow-red"
          src="../assets/images/nextgenBG.svg"
          alt=""
        />
        <div className="form pt-48 2xl:pt-60">
          <h2 className="text-red text-2xl">Welcome to</h2>
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
              id="email"
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
              id="password"
              className="drop-shadow-black pl-16 pr-10 py-4 rounded-full text-grey focus:border-none font-bold text-xs placeholder-grey w-88 outline-none"
            />
          </div>
          <div className="flex mt-5 justify-between">
            <button type="button" className="font-bold text-xs text-red ml-3">
              Forgot password?
            </button>
            {/* eslint-disable-next-line @next/next/no-html-link-for-pages */}
            <a href="/api/auth/login">
              <button
                type="button"
                id="btn-login"
                className="py-3 rounded-full text-white focus:border-none font-bold bg-nextgen w-56 outline-none drop-shadow-red hover:opacity-90"
              >
                Log in
              </button>
            </a>
          </div>
        </div>
      </div>
      <div className="bottom flex -mt-10 px-10 justify-between xl:pr-16">
        <p className="text-red font-bold text-xs">Made by We do IT</p>
        <Link href="/register">
          <button
            type="button"
            id="btn-signup"
            className="text-red font-semibold text-xs"
          >
            Don&apos;t have an account?{" "}
            <span className="font-bold">Register here!</span>
          </button>
        </Link>
      </div>
    </div>
  );
}

export default Login;
