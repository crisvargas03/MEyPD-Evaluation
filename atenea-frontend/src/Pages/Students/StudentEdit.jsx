import React from "react";
import { useForm } from "../../Hooks/UseForm";
import { useNavigate } from "react-router";
import Navbar from "../../Components/Navbar";
import Swal from "sweetalert2";
import dateFormat from "dateformat";
import { Update } from "../../Utils/StudentsMethods/Update";

export const StudentEdit = () => {
  const data = JSON.parse(localStorage.getItem("userLoged"));
  const studentToEdit = JSON.parse(localStorage.getItem("student"));
  const navigate = useNavigate();

  const initialState = {
    id: studentToEdit.id,
    name: studentToEdit.name,
    lastname: studentToEdit.lastname,
    birthdate: dateFormat(studentToEdit.birthdate, "yyyy-mm-dd"),
    phoneNumber: studentToEdit.phoneNumber,
    gender: studentToEdit.gender,
    address: studentToEdit.address,
    condition: studentToEdit.condition,
    teacherId: data.id,
  };

  const [inputs, handleChange] = useForm(initialState);
  const { name, lastname, birthdate, phoneNumber, gender, address } = inputs;

  const handleSubmit = (e) => {
    e.preventDefault();
    Update(inputs)
      .then((response) => {
        if (!response.status === 200) {
          Swal.fire({
            title: "Verificar que todos los campos esten correctos...",
            icon: "error",
          });
          return;
        }

        Swal.fire({
          title: "Estudiante Modificado Correctamente!",
          icon: "success",
        });
        handleBack();
      })
      .catch(() => {
        Swal.fire({
          title: "Ups! Algo ha salido mal...",
          icon: "error",
        });
        return;
      });
  };

  const handleBack = () => {
    localStorage.removeItem("student");
    navigate("/Students");
  };

  return (
    <div>
      <Navbar UserName={`${data.name}  ${data.lastname}`} />
      <div className="container">
        <h2 className="mt-3">Editar Estudiante</h2>
        <div className="p-2">
          <form onSubmit={handleSubmit} className="row g-3">
            <div className="col-md-6">
              <label htmlFor="name" className="form-label">
                Nombre
              </label>
              <input
                type="text"
                className="form-control"
                name="name"
                value={name}
                onChange={handleChange}
              />
            </div>

            <div className="col-md-6">
              <label htmlFor="lastname" className="form-label">
                Apellido
              </label>
              <input
                type="text"
                className="form-control"
                name="lastname"
                value={lastname}
                onChange={handleChange}
              />
            </div>

            <div className="col-6">
              <label htmlFor="birthdate" className="form-label">
                Fecha de Nacimiento
              </label>
              <input
                type="date"
                className="form-control"
                name="birthdate"
                placeholder="12-12-2000"
                value={birthdate}
                onChange={handleChange}
              />
            </div>

            <div className="col-md-6">
              <label htmlFor="phone" className="form-label">
                Numero de Telefono
              </label>
              <input
                type="phone"
                className="form-control"
                name="phoneNumber"
                value={phoneNumber === null ? "" : phoneNumber}
                onChange={handleChange}
              />
            </div>

            <div className="col-md-3">
              <label htmlFor="gender" className="form-label">
                Sexo
              </label>
              <select
                name="gender"
                className="form-select"
                value={gender}
                onChange={handleChange}
              >
                <option value={""}>Seleccionar</option>
                <option value={"F"}>Femenino</option>
                <option value={"M"}>Masculino</option>
                <option value={"X"}>Otro</option>
              </select>
            </div>

            <div className="col-md-9">
              <label htmlFor="address" className="form-label">
                Dirrecion
              </label>
              <input
                type="phone"
                className="form-control"
                name="address"
                value={address}
                onChange={handleChange}
              />
            </div>

            <div className="col-6">
              <button type="submit" className="btn btn-success">
                Guardar
              </button>
            </div>
            <div className="col-6">
              <button
                onClick={() => handleBack()}
                className="btn btn-outline-danger"
              >
                Cancelar
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};
