import React, { useState } from "react";

import moment from "moment";

import Calendar from "./Calendar";

function DatePicker() {
  const [toDate, setToDate] = useState(moment());
  const [fromDate, setFromDate] = useState(moment().subtract(1, "month"));
  const [fromCalendar, setFromCalender] = useState(false);
  const [toCalendar, setToCalender] = useState(false);

  return (
    <div className="flex items-center gap-5">
      <button
        type="button"
        onClick={() => {
          setFromCalender(!fromCalendar);
          setToCalender(false);
        }}
      >
        <p className="drop-shadow-black px-6 py-2 w-44 rounded-full text-grey bg-white focus:border-none font-semibold text-xs">
          {fromDate.format("MMMM Do YYYY")}
        </p>
      </button>
      <div
        className={
          fromCalendar
            ? "bg-white drop-shadow-black rounded-2xl absolute z-20 top-44 pb-8"
            : "hidden"
        }
      >
        <Calendar value={fromDate} onChange={setFromDate} />
      </div>
      <p className="text-black font-bold text-xs">till</p>
      <button
        type="button"
        onClick={() => {
          setToCalender(!toCalendar);
          setFromCalender(false);
        }}
      >
        <p className="drop-shadow-black px-6 py-2 w-44 rounded-full text-grey bg-white focus:border-none font-semibold text-xs">
          {toDate.isSame(moment(), "day")
            ? "today"
            : toDate.format("MMMM Do YYYY")}
        </p>
      </button>
      <div
        className={
          toCalendar
            ? "bg-white drop-shadow-black rounded-2xl absolute z-20 top-44 right-14 pb-8"
            : "hidden"
        }
      >
        <Calendar value={toDate} onChange={setToDate} />
      </div>
    </div>
  );
}

export default DatePicker;
