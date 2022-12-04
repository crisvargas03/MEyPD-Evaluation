import React, { useEffect, useState } from "react";
import Navbar from "../../Components/Navbar";
import { useNavigate } from "react-router";
import dateFormat from "dateformat";
import { Delete } from "../../Utils/StudentsMethods/Delete";
import Swal from "sweetalert2";
import { FaTrash, FaPencilAlt, FaBook } from "react-icons/fa";
import { GetByTeacher } from "../../Utils/StudentsMethods/GetByTeacher";
//import { Get } from "../../Utils/StudentsMethods/Get";

export const StudentList = () => {
  const data = JSON.parse(localStorage.getItem("userLoged"));
  const navigate = useNavigate();

  const [students, setStudents] = useState([]);
  const [filter, setFilter] = useState("");

  useEffect(() => {
    GetByTeacher(data.id).then((response) => setStudents(response));
  }, [data.id, students]);

  const studentFiltered = students.filter(
    (student) =>
      `${student.name.toLowerCase()} ${student.lastname.toLowerCase()}`.includes(
        filter
      ) | student.cardnetNumber.toLowerCase().includes(filter)
  );

  const handleClickRow = (id) => {
    // console.log(
    //   "aqui",
    //   students.filter((x) => x.id === id)
    // );
  };

  const handleEdit = (student) => {
    localStorage.setItem("student", JSON.stringify(student));
    navigate("Edit");
  };

  const handleDelete = (id) => {
    Delete(id)
      .then((response) => {
        if (!response.status === 200) {
          Swal.fire({
            title: "Ha ocurrido un error",
            icon: "error",
          });
          return;
        }

        Swal.fire({
          title: "Estudiante eliminado Correctamente!",
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
    <div>
      <Navbar UserName={`${data.name}  ${data.lastname}`} />
      <div className="container-fluid">
        <h2>Estudiantes Inscritos!</h2>
        <div>
          <button
            onClick={() => navigate("/students/create")}
            className="btn btn-success m-3"
          >
            Registar Estudiante
          </button>
          <div className="mt-3 col-md-12 ">
            <input
              type="text"
              className="form-control"
              name="filter"
              onChange={(e) => setFilter(e.target.value.toLowerCase())}
              placeholder="filtrar..."
            />
          </div>
        </div>
        <div className="mt-3">
          <table className="table table-striped table-hover text-center">
            <thead className="">
              <tr>
                <th>Nombre</th>
                <th>Fecha de Naciemento</th>
                <th>Numero de Carnet</th>
                <th>Genero</th>
                <th>Condicion</th>
                <th>Dirrecion</th>
                <th>Opciones</th>
              </tr>
            </thead>
            <tbody>
              {studentFiltered.map((stu) => (
                <tr onClick={() => handleClickRow(stu.id)} key={stu.id}>
                  <td>{`${stu.name} ${stu.lastname}`}</td>
                  <td>{dateFormat(stu.birthdate, "dd-mm-yyyy")}</td>
                  <td>{stu.cardnetNumber}</td>
                  <td>{stu.gender}</td>
                  <td>{stu.condition}</td>
                  <td>{stu.address}</td>
                  <td className="text-center">
                    <button
                      onClick={() => handleEdit(stu)}
                      className="btn btn-primary m-1"
                    >
                      <FaPencilAlt />
                    </button>
                    <button className="btn btn-secondary text-white m-1">
                      <FaBook />
                    </button>
                    <button
                      onClick={() => handleDelete(stu.id)}
                      className="btn btn-danger m-1"
                    >
                      <FaTrash />
                    </button>
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
    </div>
  );
};
