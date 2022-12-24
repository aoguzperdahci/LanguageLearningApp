import React, { useState } from 'react';
import { Button } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { saveAnswer } from '../../redux/ExamSlice';
import "./TestQuestion.css";

const TestQuestion = () => {
    const student = useSelector(state => state.user);
    const exam = useSelector(state => state.exam);
    const dispatch = useDispatch();
    const [answer, setAnswer] = useState("");

    const renderExamDifficulty = () => {
        let difficulty = <></>
        switch (exam.question.difficulty) {
            case 0:
                difficulty = <span className="text-success">Easy</span>
                break;
            case 1:
                difficulty = <span className="text-warning">Medium</span>
                break;
            case 2:
                difficulty = <span className="text-danger">Hard</span>
                break;
            default:
                break;
        }

        return difficulty;
    }

    const submitAnswer = () => {
        console.log("submit", answer);
        dispatch(saveAnswer({studentId: student.id, answer:answer}));
    }

    return (
        <div className="test-question">
            <div className="w-50 d-inline-block text-start fs-5">Question: {exam.questionNumber}/10</div>
            <div className="w-50 d-inline-block text-end fs-5">Difficulty: {renderExamDifficulty()}</div>
            <p className="fs-4 mt-4">Fill the blank by choosing a choice the answer for the question below.</p>
            <p className="fs-4 mt-2">{exam.question.questionText}</p>

            <div className="form-check text-start fs-5">
                <input className="form-check-input" type="radio" name="choice" id="choiceA" value={exam.question.choiceA} onChange={(e) => setAnswer(e.target.value)}/>
                <label className="form-check-label" htmlFor="choiceA">{exam.question.choiceA}</label>
            </div>
            <div className="form-check text-start fs-5">
                <input className="form-check-input" type="radio" name="choice" id="choiceB" value={exam.question.choiceB} onChange={(e) => setAnswer(e.target.value)}/>
                <label className="form-check-label" htmlFor="choiceB">{exam.question.choiceB}</label>
            </div>
            <div className="form-check text-start fs-5">
                <input className="form-check-input" type="radio" name="choice" id="choiceC" value={exam.question.choiceC} onChange={(e) => setAnswer(e.target.value)}/>
                <label className="form-check-label" htmlFor="choiceC">{exam.question.choiceC}</label>
            </div>
            <div className="form-check text-start fs-5">
                <input className="form-check-input" type="radio" name="choice" id="choiceD" value={exam.question.choiceD} onChange={(e) => setAnswer(e.target.value)}/>
                <label className="form-check-label" htmlFor="choiceD">{exam.question.choiceD}</label>
            </div>
            <div className="form-check text-start fs-5">
                <input className="form-check-input" type="radio" name="choice" id="choiceE" value={exam.question.choiceE} onChange={(e) => setAnswer(e.target.value)}/>
                <label className="form-check-label" htmlFor="choiceE">{exam.question.choiceE}</label>
            </div>

            <Button className="fs-5 py-2 px-3 question-submit-button" onClick={() => submitAnswer()} disabled={exam.status === "loading"}>{exam.questionNumber === 10 ? "Finish Exam" : "Next Question"}</Button>
        </div>
    )
}

export default TestQuestion