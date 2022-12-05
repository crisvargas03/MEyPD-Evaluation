import React from "react";
import Navbar from "../../Components/Navbar";
import { useNavigate } from "react-router";
import { useState } from "react";
import { useEffect } from "react";
import { GetByTeacher } from "../../Utils/StudentsMethods/GetByTeacher";
import { AiOutlineCheck, AiOutlineClose } from "react-icons/ai";

const Attendance = () => {
  const navigate = useNavigate();
  const data = localStorage.getItem("userLoged")
    ? JSON.parse(localStorage.getItem("userLoged"))
    : null;
  if (data === null) {
    navigate("/");
  }

  const initialState = { studenId: 0, isPresent: true, justification: "" };

  const [students, setStudents] = useState([]);

  useEffect(() => {
    GetByTeacher(data.id).then((response) => setStudents(response));
  }, [data.id, students]);

  return (
    <>
      <div className="App" id="top">
        <Navbar UserName={`${data.name}  ${data.lastname}`} />
        <div className="container-fluid mt-3">
          <table className="table table-sm text-center">
            <thead className="thead-dark">
              <tr>
                <th>Estudiante</th>
                <th>Asistencia</th>
                <th>Justificacion</th>
              </tr>
            </thead>
            <tbody>
              {students.map((st) => (
                <tr key={st.id}>
                  <td>{`${st.name} ${st.lastname}`}</td>
                  <td>
                    <button className="btn btn-success btn-sm m-1">
                      <AiOutlineCheck />
                    </button>
                    <button className="btn btn-danger btn-sm m-1">
                      <AiOutlineClose />
                    </button>
                  </td>
                  <td>
                    <input type="text" className="form-control" name="filter" />
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
};

export default Attendance;
