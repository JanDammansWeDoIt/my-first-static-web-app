import { UserProvider } from "@auth0/nextjs-auth0";
import { AppProps } from "next/app";

import "@we-do-it/react-component-library/dist/WDIComponentLibraryStyles.css";
import "../styles/main.css";
import Layout from "../layout/layout";

const NextGen = ({ Component, pageProps }: AppProps) => (
  <UserProvider>
    <div className="flex">
      <Layout>
        <div className="w-full">
          {/* eslint-disable-next-line react/jsx-props-no-spreading */}
          <Component {...pageProps} />
        </div>
      </Layout>
    </div>
  </UserProvider>
);

export default NextGen;
