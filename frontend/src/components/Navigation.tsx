import React from "react";

import { Linker, SideNavigation } from "@we-do-it/react-component-library";
import NextLink from "next/link";
import { useRouter } from "next/router";

export enum NavigationItems {
  Home = "home",
  Dashboard = "dashboard",
  Blocks = "blocks",
  Logout = "logout",
}

function Navigation() {
  const router = useRouter();
  const selected =
    router.route.replace("/", "") !== ""
      ? router.route.replace("/", "")
      : "home";

  return (
    <Linker CustomLink={NextLink}>
      <SideNavigation
        logo="../../assets/icons/logo.svg"
        selected={selected}
        listItems={[
          {
            icon: "../../assets/icons/home.svg",
            name: NavigationItems.Home,
            url: "/",
            useCustomLink: true,
          },
          {
            icon: "../../assets/icons/dashboard.svg",
            name: NavigationItems.Dashboard,
            url: "/dashboard",
            useCustomLink: true,
          },
          {
            icon: "../../assets/icons/blocks.svg",
            name: NavigationItems.Blocks,
            url: "/blocks",
            useCustomLink: true,
          },
        ]}
        footerItem={{
          icon: "../../assets/icons/settings.svg",
          name: NavigationItems.Logout,
          url: "/api/auth/logout",
          useCustomLink: false,
        }}
      />
    </Linker>
  );
}

export default Navigation;
