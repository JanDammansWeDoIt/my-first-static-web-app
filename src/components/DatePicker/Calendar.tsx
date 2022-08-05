import React, { useEffect, useState } from "react";

// @ts-ignore:next-line
import buildCalendar from "../../utils/buildCalendar";
// @ts-ignore:next-line
import dayStyles from "../../utils/calendarStyles";

export default function Calendar({
  value,
  onChange,
}: {
  value: any;
  onChange: any;
}) {
  const [calendar, setCalendar] = useState([]);

  useEffect(() => {
    setCalendar(buildCalendar(value));
  }, [value]);

  function currMonthName() {
    return value.format("MMMM");
  }

  function prevMonth() {
    return value.clone().subtract(1, "month");
  }

  function nextMonth() {
    return value.clone().add(1, "month");
  }

  return (
    <div className="calendar">
      <div className="flex justify-end mb-4">
        <div className="flex px-4 pt-1.5 justify-between gap-x-2 items-center w-28 mt-3 mr-6">
          <button
            type="button"
            className="cursor-pointer"
            onClick={() => onChange(prevMonth())}
          >
            <img
              src=".././assets/icons/previous.svg"
              alt="previous month"
              className="w-1.5"
            />
          </button>
          <p className="font-semibold text-black text-xs">
            {currMonthName().toLowerCase()}
          </p>
          <button
            type="button"
            className="cursor-pointer"
            onClick={() => onChange(nextMonth())}
          >
            <img
              src=".././assets/icons/next.svg"
              alt="next month"
              className="w-1.5"
            />
          </button>
        </div>
      </div>
      <div className="daysOfWeek flex justify-between px-10 rounded-full bg-white font-bold text-black text-xs">
        {[
          { key: 0, value: "M" },
          { key: 1, value: "T" },
          { key: 2, value: "W" },
          { key: 3, value: "T" },
          { key: 4, value: "F" },
          { key: 5, value: "S" },
          { key: 6, value: "S" },
        ].map((d) => (
          <p key={d.key}>{d.value}</p>
        ))}
      </div>
      <div className="dates">
        {calendar.map((week: any) => (
          <div
            key={week}
            className="py-3 2xl:py-4 px-7 w-full flex justify-between mx-auto"
          >
            {week.map((day: any) => (
              <div
                aria-hidden
                key={day}
                onClick={() => onChange(day)}
                onKeyDown={() => onChange(day)}
                className="relative w-8 h-3 inline-block text-xs text-black font-bold p-0 m-0 text-center cursor-pointer"
              >
                <div className={dayStyles(day, value)}>{day.format("D")}</div>
              </div>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
}
