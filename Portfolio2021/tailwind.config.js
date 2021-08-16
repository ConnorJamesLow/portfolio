let colors = require('tailwindcss/colors');
const { theme: { screens } } = require('tailwindcss/defaultConfig')

delete colors.lightBlue;

const config = {
  purge: ['./{wwwsrc,Pages,Shared}/**/*.{cs,css,ts,razor,cshtml,json}', './*.razor', './wwwroot/**/*.{html,json}', './.tailwindinclude'],
  mode: 'jit',
  darkMode: 'class', // or 'media' or 'class'
  theme: {
    colors: {
      ...colors,
      transparent: 'transparent',
      current: 'currentColor',
      primary: colors.indigo,
      secondary: colors.cyan,
    },
    screens: {
      'mobile': {
        'max': `${parseInt(screens.sm) - 1}px`,
      },
      ...screens,
    },
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [],
}

module.exports = config;