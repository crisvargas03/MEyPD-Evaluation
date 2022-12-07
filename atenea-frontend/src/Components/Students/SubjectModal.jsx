import React, { useEffect } from "react";
import { useState } from "react";
import { Modal, ModalBody, ModalHeader, ModalFooter } from "reactstrap";
import { useForm } from "../../Hooks/UseForm";
import { GetSubjects } from "../../Utils/GradesMethods/GetSubjects";
import { LiteralCalifications } from "../../Utils/GradesMethods/LiteralCalifications";
import { Save } from "../../Utils/GradesMethods/Save";
import Swal from "sweetalert2";

const SubjectModal = ({ ModalOpen, CloseModal, StudentData }) => {
  const initialState = {
    studentId: StudentData.id,
    studentName: `${StudentData.name} ${StudentData.lastname}`,
    subjectId: 0,
    grade: 0,
  };
  const [subjects, setSubjects] = useState([]);

  const [inputs, handleChange, reset] = useForm(initialState);
  const { studentName, subjectId, grade } = inputs;

  useEffect(() => {
    GetSubjects().then((response) => setSubjects(response));
  }, []);

  const handleSave = () => {
    Save(inputs)
      .then((response) => {
        if (!response.status === 200) {
          Swal.fire({
            title: "Verificar que todos los campos esten correctos...",
            icon: "error",
          });
          return;
        }

        Swal.fire({
          title: "Calificacion registrada con exito Correctamente!",
          icon: "success",
        });
        CloseModal();
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
    <Modal isOpen={ModalOpen}>
      <ModalHeader>
        <div>
          <h3>Calificacion {`${StudentData.name} ${StudentData.lastname}`}</h3>
        </div>
      </ModalHeader>
      <ModalBody className="form-group ">
        <div className="row g-3">
          <div className="col-7">
            <label htmlFor="studentName" className="form-label">
              Estudiante
            </label>
            <input
              className="form-control"
              readOnly
              type="text"
              name="studentName"
              value={studentName}
            />
          </div>
          <br />
          <div className="col-5">
            <label htmlFor="subjectId" className="form-label">
              Asignatura
            </label>
            <select
              name="subjectId"
              className="form-select"
              value={subjectId}
              onChange={handleChange}
            >
              <option value={""}>Seleccionar</option>
              {subjects.map((sub) => (
                <option key={sub.id} value={sub.id}>
                  {sub.name}
                </option>
              ))}
            </select>
          </div>
          <div className="col-5">
            <label htmlFor="grade" className="form-label">
              Calificacion
            </label>
            <input
              className="form-control"
              type="number"
              name="grade"
              onChange={handleChange}
              value={grade}
            />
          </div>
          <div className="col-5">
            <label className="form-label">Calificacion Literal</label>
            <input
              className="form-control"
              readOnly
              type="text"
              value={LiteralCalifications(grade)}
            />
          </div>
        </div>
      </ModalBody>
      <ModalFooter>
        <button onClick={() => handleSave(inputs)} className="btn btn-success">
          Guardar
        </button>
        <button className="btn btn-danger" onClick={() => CloseModal()}>
          Cancelar
        </button>
      </ModalFooter>
    </Modal>
  );
};

export default SubjectModal;
