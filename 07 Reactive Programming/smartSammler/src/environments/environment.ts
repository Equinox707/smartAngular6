// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  googleApiKey: "AIzaSyDu1TiJaGinxTX7pI9daPqTqwNJ8d4fQk0",
  appName: "smart Sammler",
  // markerHub: "http://localhost:5000/markerhub",
  // apiURL: "http://localhost:5000/api/"
  markerHub: "https://localhost:44395/markerhub",
  apiURL: "https://localhost:44395/api/"
};
