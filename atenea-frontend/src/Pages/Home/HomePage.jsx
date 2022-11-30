import React from "react";
import Navbar from "../../Components/Navbar";
import "./homepage.css";
import { useLocation } from "react-router-dom";
import { Welcome } from "../../Components/Welcome";

const HomePage = () => {
  const location = useLocation();
  // DATA = info del login
  const { name, lastname, email, id } = location.state.data;
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
