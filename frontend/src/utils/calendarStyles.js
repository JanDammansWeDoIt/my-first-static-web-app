function isSelected(day, value) {
  return value.isSame(day, "day");
}

function isToday(day) {
  return day.isSame(new Date(), "day");
}

export default function dayStyles(day, value) {
  if (isSelected(day, value))
    return "bg-red rounded-full text-white py-2 md:py-2";
  if (isToday(day))
    return "bg-red bg-opacity-50 text-opacity-30 rounded-full text-white py-2 md:py-2";
  return "py-2 md:py-2";
}
