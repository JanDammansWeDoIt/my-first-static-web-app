import Meta from "../components/Meta";
import Navigation from "../components/Navigation";

function Layout({ children }: any) {
  const description =
    "We do IT | Experts in Business Blockchain | We build your applications. Want to receive a quote? Fill out a new Project request.";

  return (
    <>
      <Meta title="NextGen | We do IT" description={description} />
      <Navigation />
      {children}
    </>
  );
}

export default Layout;
