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

  const [isPresent, setIsPresent] = useState(true);
  const [justify, setJustify] = useState("");
  const [studentId, setStudentId] = useState(0);
  const [attendanceList, setAttanceList] = useState([{}]);

  const [students, setStudents] = useState([]);
  useEffect(() => {
    GetByTeacher(data.id).then((response) => setStudents(response));
  }, [data.id, students]);

  const handleAttendace = (present, stu) => {
    const initialState = {
      studenId: studentId,
      isPresent: isPresent,
      justification: justify,
    };
    setIsPresent(present);
    setStudentId(stu);
    setAttanceList((old) => [...old, initialState]);
    console.log(attendanceList);
  };
  return (
    <>
      <div className="App" id="top">
        <Navbar UserName={`${data.name}  ${data.lastname}`} />
        <div className="container-fluid mt-3">
          <table className="table table-sm text-center">
            <thead className="thead-dark">
              <tr>
                <th>Estudiante</th>
                <th>Justificacion</th>
                <th>Asistencia</th>
              </tr>
            </thead>
            <tbody>
              {students.map((st) => (
                <tr key={st.id}>
                  <td>{`${st.name} ${st.lastname}`}</td>
                  <td>
                    <input
                      type="text"
                      onChange={(e) => setJustify(e.target.value)}
                      className="form-control"
                      name="justification"
                    />
                  </td>
                  <td>
                    <button
                      onChange={(e) => console.log(e.target.value)}
                      onClick={() => handleAttendace(true, st.id)}
                      className="btn btn-success btn-sm m-1"
                    >
                      <AiOutlineCheck />
                    </button>
                    <button
                      onClick={() => handleAttendace(false, st.id)}
                      className="btn btn-danger btn-sm m-1"
                    >
                      <AiOutlineClose />
                    </button>
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
