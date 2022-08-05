import React, { Dispatch, SetStateAction } from "react";

type FilterButtonProps = {
  buttonText: string;
  selected: string;
  setSelected: Dispatch<SetStateAction<string>>;
};

function FilterButton({
  buttonText,
  selected,
  setSelected,
}: FilterButtonProps) {
  return (
    <button
      className={
        selected === buttonText
          ? "font-bold text-lg text-black order-0"
          : "font-semibold text-sm text-black opacity-50 order-1"
      }
      onClick={() => setSelected(buttonText)}
      type="button"
    >
      {buttonText}
    </button>
  );
}

export default FilterButton;
