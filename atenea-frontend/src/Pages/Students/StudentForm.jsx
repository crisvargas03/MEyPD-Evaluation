import React from "react";
import { useForm } from "../../Hooks/UseForm";
import { Create } from "../../Utils/StudentsMethods/Create";
import { useNavigate } from "react-router";
import Navbar from "../../Components/Navbar";
import Swal from "sweetalert2";

export const StudentForm = () => {
  const data = JSON.parse(localStorage.getItem("userLoged"));
  const navigate = useNavigate();
  const initialState = {
    name: "",
    lastName: "",
    birthdate: "",
    phoneNumber: "",
    gender: "",
    address: "",
    teacherId: data.id,
  };
  const [inputs, handleChange, reset] = useForm(initialState);
  const { name, lastName, birthdate, phoneNumber, gender, address } = inputs;

  const handleSubmit = (e) => {
    e.preventDefault();

    Create(inputs)
      .then((response) => {
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
        reset();
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
      <div className="container">
        <h2 className="mt-3">Registrar Estudiante</h2>
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
              <label htmlFor="lastName" className="form-label">
                Apellido
              </label>
              <input
                type="text"
                className="form-control"
                name="lastName"
                value={lastName}
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
                value={phoneNumber}
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
                onClick={() => navigate("/Students")}
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
