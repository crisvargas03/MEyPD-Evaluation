import React from "react";
import Navbar from "../../Components/Navbar";
import "./homepage.css";
import { Welcome } from "../../Components/Welcome";

const HomePage = () => {
  const data = JSON.parse(localStorage.getItem("userLoged"));
  const { name, lastname } = data;
  return (
    <>
      <div className="App" id="top">
        <Navbar UserName={`${name}  ${lastname}`} />
        <Welcome />
      </div>
    </>
  );
};

export default HomePage;
