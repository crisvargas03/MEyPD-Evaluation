import React from "react";
import student from "../Assets/images/student.png";
import attandance from "../Assets/images/attendance.png";
import { useNavigate } from "react-router-dom";

const ServiceCards = () => {
  const navigate = useNavigate();
  return (
    <div className="row g-3">
      <div className="col-md-6">
        <div className="card mb-4 shadow-sm">
          <div className="card-header">
            <h4 className="my-0 font-weight-normal">Servicio de Estudiantes</h4>
          </div>
          <div className="card-body">
            <ul className="list-unstyled mt-3 mb-4"></ul>
            <img src={student} alt="foto" className="card-img-top pt-3" />
            <button
              onClick={() => navigate("/students")}
              className="btn btn-lg btn-block btn-outline-primary"
              type="button"
            >
              Visitar el Servicio
            </button>
          </div>
        </div>
      </div>
      <div className="col-md-6">
        <div className="card mb-4 shadow-sm">
          <div className="card-header">
            <h4 className="my-0 font-weight-normal">Pase de Lista</h4>
          </div>
          <div className="card-body">
            <ul className="list-unstyled mt-3 mb-4"></ul>
            <img src={attandance} alt="foto" className="card-img-top pt-1" />
            <button
              className="btn btn-lg btn-block btn-outline-primary"
              type="button"
            >
              Visitar el Servicio
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ServiceCards;
