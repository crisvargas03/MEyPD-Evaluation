import React, { useEffect, useState } from "react";
import { Get } from "../../Utils/StudentsMethods/Get";
import { useNavigate } from "react-router";
import dateFormat from "dateformat";

export const StudentList = () => {
  const [students, setStudents] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    Get().then((response) => setStudents(response));
  }, []);

  const handleClickRow = (id) => {
    console.log(
      "aqui",
      students.filter((x) => x.id === id)
    );
  };

  return (
    <div className="container">
      <h2>Estudiantes Inscritos!</h2>
      <div>
        <button
          onClick={() => navigate("/students/create")}
          className="btn btn-success m-3"
        >
          Registar Estudiante
        </button>
      </div>
      <div className="mt-5">
        <table className="table table-striped table-hover">
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Fecha de Naciemento</th>
              <th>Numero de Carnet</th>
              <th>Genero</th>
              <th>Dirrecion</th>
              <th>Opciones</th>
            </tr>
          </thead>
          <tbody>
            {students.map((stu) => (
              <tr key={stu.id}>
                <td>{`${stu.name} ${stu.lastname}`}</td>
                <td>{dateFormat(stu.birthdate, "dd - mm - yyyy")}</td>
                <td>{stu.cardnetNumber}</td>
                <td>{stu.gender}</td>
                <td>{stu.address}</td>
                <td>
                  <button
                    onClick={() => handleClickRow(stu.id)}
                    className="btn btn-primary m-1"
                  >
                    Ver
                  </button>
                  <button className="btn btn-danger m-1">del</button>
                  <button className="btn btn-info m-1">cal</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div className="center">
        <button
          onClick={() => navigate("/Home")}
          className="btn btn-outline-dark"
        >
          Volver
        </button>
      </div>
    </div>
  );
};
