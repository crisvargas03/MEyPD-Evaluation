import React, { useState } from "react";
import { useForm } from "../../Hooks/UseForm";
import Swal from "sweetalert2";
import photo from "../../Assets/images/login.png";
import "./Login.css";
import { LogIn } from "../../Utils/LoginMethod";
import Loader from "../../Components/Loader";
import { useNavigate } from "react-router";

const Login = () => {
  const initialState = {
    email: "pmartinez@mail.com",
    password: "@pm12345",
  };

  const [isLoanding, setIsLoanding] = useState(false);
  const navigate = useNavigate();

  const [inputs, handleChange] = useForm(initialState);
  const { email, password } = inputs;

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!email.trim()) {
      Swal.fire({
        title: "Campos Vacios",
        icon: "error",
      });
      e.target[0].focus();
      return;
    }

    if (!password.trim()) {
      Swal.fire({
        title: "Campos Vacios",
        icon: "error",
      });
      e.target[1].focus();
      return;
    }

    setIsLoanding(true);

    LogIn(inputs).then((response) => {
      if (!response.status === 200) {
        setIsLoanding(false);
        Swal.fire({
          title: "Favor Verficar sus crendenciales...",
          icon: "error",
        });
        return;
      }

      setIsLoanding(false);
      navigate("Home");
    });
  };

  if (isLoanding) {
    return (
      <div className="Auth-form-container">
        <Loader />
      </div>
    );
  }

  return (
    <div className="Auth-form-container">
      <form onSubmit={handleSubmit} className="Auth-form">
        <div className="Auth-form-content">
          {/* <h3 className="Auth-form-title">Iniciar Sesion</h3> */}
          <img src={photo} className="img-login" alt="login" />
          <div className="form-group mt-3">
            <label>Correo Electronico</label>
            <input
              type="email"
              className="form-control mt-1"
              placeholder="Enter email"
              name="email"
              value={email}
              onChange={handleChange}
            />
          </div>
          <div className="form-group mt-3">
            <label>Contraseña</label>
            <input
              type="password"
              className="form-control mt-1"
              placeholder="Enter password"
              name="password"
              value={password}
              onChange={handleChange}
            />
          </div>
          <div className="d-grid gap-2 mt-3">
            <button type="submit" className="btn btn-primary">
              Iniciar
            </button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default Login;
