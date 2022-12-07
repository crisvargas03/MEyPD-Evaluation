import React from "react";
import Navbar from "../../Components/Navbar";
import { useNavigate } from "react-router";

const Report = () => {
  const data = JSON.parse(localStorage.getItem("userLoged"));
  const navigate = useNavigate();
  return (
    <div className="App" id="top">
      <Navbar UserName={`${data.name}  ${data.lastname}`} />
      <div className="container-fluid mt-3">
        <h2>Reporte Diario</h2>
      </div>
    </div>
  );
};

export default Report;
