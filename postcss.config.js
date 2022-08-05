// Don't use the array form (like ['tailwindcss', 'postcss-preset-env'])
// --> error: Invalid PostCSS Plugin found: [0]

module.exports = {
  plugins: { tailwindcss: {}, autoprefixer: {} },
};
