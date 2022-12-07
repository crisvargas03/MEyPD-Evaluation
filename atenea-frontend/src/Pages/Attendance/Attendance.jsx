import React from "react";
import Navbar from "../../Components/Navbar";
import { useNavigate } from "react-router";
import { useState, useEffect } from "react";
import { GetByTeacher } from "../../Utils/StudentsMethods/GetByTeacher";
import { SaveAttendance } from "../../Utils/AttendanceMethods/SaveAttendace";
import Swal from "sweetalert2";

const Attendance = () => {
  const navigate = useNavigate();
  const data = localStorage.getItem("userLoged")
    ? JSON.parse(localStorage.getItem("userLoged"))
    : null;
  if (data === null) {
    navigate("/");
  }
  const [students, setStudents] = useState([]);
  useEffect(() => {
    GetByTeacher(data.id).then((response) => setStudents(response));
  }, [data.id]);

  const [check, setCheck] = useState();

  let studentConfirmed = [];
  const handleConfirm = (value, isPresent) => {
    studentConfirmed.push({ StudentId: value, IsPresent: isPresent });
    console.log(studentConfirmed);
  };

  const sendStudent = () => {
    SaveAttendance(studentConfirmed)
      .then((response) => {
        console.log(response);
        if (!response.status === 200) {
          Swal.fire({
            title: "Verificar que todos los campos esten correctos...",
            icon: "error",
          });
          return;
        }
        Swal.fire({
          title: "Estudiante Inscrito Correctamente!",
          icon: "success",
        });
      })
      .catch(() => {
        Swal.fire({
          title: "Ups! Algo ha salido mal...",
          icon: "error",
        });
        return;
      });
  };

  return (
    <>
      <div className="App" id="top">
        <Navbar UserName={`${data.name}  ${data.lastname}`} />
        <div className="container-fluid mt-3">
          <h2>Pase de Lista</h2>
          <table className="table table-sm text-center">
            <thead className="thead-dark">
              <tr>
                <th>Estudiante</th>
                <th>Asistencia</th>
                <th>Opcion</th>
              </tr>
            </thead>
            <tbody>
              {students.map((st) => (
                <tr key={st.id}>
                  <td>{`${st.name} ${st.lastname}`}</td>
                  <td>
                    <div className="form-check mb-3">
                      <input
                        id="idCheckbox"
                        className="form-check-input mb-2"
                        type="checkbox"
                        onChange={(e) => setCheck(e.currentTarget.checked)}
                      />
                    </div>
                  </td>
                  <td>
                    <button
                      onClick={(e) => handleConfirm(st.id, check)}
                      className="btn btn-primary"
                    >
                      Confirmar
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <button className="btn btn-success" onClick={() => sendStudent()}>
            Enviar pase de Lista
          </button>
          <button
            onClick={() => navigate("/Home")}
            className="btn btn-dark m-1"
          >
            Volver
          </button>
        </div>
      </div>
    </>
  );
};

export default Attendance;
