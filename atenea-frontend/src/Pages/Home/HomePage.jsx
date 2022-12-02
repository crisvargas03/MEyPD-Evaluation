import React from "react";
import Navbar from "../../Components/Navbar";
import "./homepage.css";
import { Welcome } from "../../Components/Welcome";
import { useNavigate } from "react-router";

const HomePage = () => {
  const navigate = useNavigate();
  const data = localStorage.getItem("userLoged")
    ? JSON.parse(localStorage.getItem("userLoged"))
    : null;
  if (data === null) {
    navigate("/");
  }
  return (
    <>
      <div className="App" id="top">
        <Navbar UserName={`${data.name}  ${data.lastname}`} />
        <Welcome />
      </div>
    </>
  );
};

export default HomePage;
