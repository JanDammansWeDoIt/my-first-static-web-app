/* eslint-disable global-require */
/* eslint-disable import/no-extraneous-dependencies */
module.exports = {
  mode: "jit",
  purge: ["./src/**/*.{js,ts,jsx,tsx}"],
  darkMode: false,
  theme: {
    fontSize: {
      xxs: "0.675rem",
      xs: "0.75rem",
      sm: "0.875rem",
      base: "1rem",
      lg: "1.125rem",
      xl: "1.25rem",
      "2xl": "1.5rem",
      "3xl": "1.875rem",
      "4xl": "2.25rem",
      "5xl": "3rem",
      "6xl": "4rem",
    },
    extend: {
      colors: {
        gray: {
          100: "#f7fafc",
          200: "#edf2f7",
          300: "#e2e8f0",
          400: "#cbd5e0",
          500: "#a0aec0",
          600: "#718096",
          700: "#4a5568",
          800: "#2d3748",
          900: "#1a202c",
        },
        blue: {
          100: "#ebf8ff",
          200: "#bee3f8",
          300: "#90cdf4",
          400: "#63b3ed",
          500: "#4299e1",
          600: "#3182ce",
          700: "#2b6cb0",
          800: "#2c5282",
          900: "#2a4365",
        },
        red: "#FD223D",
        orange: "#FF5E10",
        black: "#262626",
        grey: "#696969",
        statusYellow: "#FCDE7C",
        statusRed: "#FF6969",
        statusGreen: "#81DD88",
        commandGray: "#EBEBEB",
      },
      maxWidth: {
        "3/10": "30%",
        "11/12": "0.91666666667%",
      },
      spacing: {
        "9/10": "90%",
        88: "23rem",
      },
      dropShadow: {
        red: "20px 20px 40px rgba(239, 99, 99, 0.33)",
        black: "10px 10px 20px rgba(0, 0, 0, 0.11)",
        hardBlack: "0px 10px 10px rgba(0, 0, 0, 0.16)",
      },
      backgroundImage: {
        nextgen:
          "linear-gradient(to right bottom, rgba(253, 34, 61, 1), rgba(255, 94, 16, 1))",
      },
    },
  },
  variants: {
    scrollbar: ["rounded"],
  },
  plugins: [require("tailwind-scrollbar")],
};
