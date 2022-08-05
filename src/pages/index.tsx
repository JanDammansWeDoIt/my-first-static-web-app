import { useEffect } from "react";

import { useUser } from "@auth0/nextjs-auth0";
import { useRouter } from "next/router";

import Welcome from "../components/Welcome";

const Index = () => {
  const { user, isLoading } = useUser();
  const router = useRouter();

  useEffect(() => {
    if (!isLoading && !user) {
      router.push("/api/auth/login");
    }
  }, [isLoading, router, user]);

  if (!user) {
    return <div />;
  }
  return (
    <>
      <div className="flex">
        <Welcome />
      </div>
    </>
  );
};

export default Index;
