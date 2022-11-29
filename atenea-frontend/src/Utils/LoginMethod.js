export const LogIn = async (user) => {
  const url = process.env.REACT_APP_API_URL + "api/auth/login";
  const methodPOST = {
    method: "POST",
    body: JSON.stringify(user),
    headers: {
      "Content-Type": "application/json",
    },
  };

  const resp = await fetch(url, methodPOST);
  const data = await resp.json();

  return await data;
};
