export const Update = async (student) => {
  const url = process.env.REACT_APP_API_URL + `api/student/edit/${student.id}`;
  const methodPOST = {
    method: "PUT",
    body: JSON.stringify(student),
    headers: {
      "Content-Type": "application/json",
    },
  };

  const resp = await fetch(url, methodPOST);
  const data = await resp.json();

  return await data;
};
