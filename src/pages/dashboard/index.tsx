import React, { useEffect } from "react";

import { useUser } from "@auth0/nextjs-auth0";
import { useRouter } from "next/router";

import Dashboard from "../../components/Projects/Dashboard";

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
    <div className="flex">
      <Dashboard />
    </div>
  );
};

export default Index;
