import { useForm } from "react-hook-form";
import api from "../api/axios";
import { useAuth } from "../hooks/useAuth";
import { useNavigate } from "react-router-dom";

type Form = { email: string; password: string };

export default function Login() {
  const { register, handleSubmit } = useForm<Form>();
  const { setToken } = useAuth();
  const navigate = useNavigate();

  const onSubmit = async (data: Form) => {
    try {
      const res = await api.post("/auth/login", data);
      setToken(res.data.token);
      navigate("/dashboard");
    } catch (e: any) {
      alert(e.response?.data?.error || "Login failed");
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="p-4 max-w-md mx-auto">
      <h2 className="text-xl font-bold mb-4">Login</h2>
      <input {...register("email")} placeholder="Email" />
      <input type="password" {...register("password")} placeholder="Password" />
      <button type="submit">Login</button>
      <a href="/register">Register</a>
    </form>
  );
}
