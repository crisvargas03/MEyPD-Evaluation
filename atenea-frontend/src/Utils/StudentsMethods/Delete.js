export const Delete = async (id) => {
  const url = process.env.REACT_APP_API_URL + `api/student/delete/${id}`;
  const repuesta = await fetch(url, { method: "DELETE" });

  return repuesta;
};
