import React from "react";

import Link from "next/link";

interface HeaderProps {
  title: string;
}

export const Header = ({ title }: HeaderProps) => {
  return (
    <div className="flex items-center justify-between mb-12">
      <h2 className="text-black text-xl">{title}</h2>
      <div className="flex justify-between gap-8">
        <div className="inputfield relative">
          <div className="icon absolute z-10 mt-1 right-8">
            <img
              className="w-3 mt-4 ml-7"
              src="../assets/icons/search.svg"
              alt=""
            />
          </div>
          <input
            type="text"
            placeholder="Search"
            id="searchbar"
            className="drop-shadow-black pl-8 pr-10 py-4 rounded-full text-grey focus:border-none font-bold placeholder-shown:font-semibold text-xs placeholder-text-grey w-88 outline-none"
          />
        </div>
        <Link href="/createProject">
          <button
            type="button"
            className="py-3 rounded-full text-white focus:border-none font-bold bg-nextgen w-56 outline-none drop-shadow-red hover:opacity-90 text-sm"
          >
            New Project
          </button>
        </Link>
      </div>
    </div>
  );
};
