import React, { useEffect, useState } from "react";
import { Get } from "../../Utils/StudentsMethods/Get";
import { useNavigate } from "react-router";

export const StudentList = () => {
  const [students, setStudents] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    Get().then((response) => setStudents(response));
  }, []);

  console.log(students);

  return (
    <div className="container">
      <h2>Estudiantes Inscritos!</h2>
      <div className="mt-5">
        <table className="table table-striped table-hover">
          <thead>
            <th>Nombre</th>
            <th>Fecha de Naciemento</th>
            <th>Numero de Carnet</th>
            <th>Genero</th>
            <th>Numero de Telefono</th>
            <th>Dirrecion</th>
          </thead>
          <tbody>
            {students.map((stu) => (
              <tr key={stu.id}>
                <td>{`${stu.name} ${stu.lastname}`}</td>
                <td>{stu.birthdate}</td>
                <td>{stu.cardnetNumber}</td>
                <td>{stu.gender}</td>
                <td>{stu.phoneNumber}</td>
                <td>{stu.address}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};
