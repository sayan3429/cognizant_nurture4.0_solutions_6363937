import React from 'react';
import '../Stylesheets/mystyle.css';

// Helper to calculate percentage
const percentToDecimal = (decimal) => `${Number(decimal).toFixed(2)}%`;

const calcScore = (total, goal) => {
  if (!goal || isNaN(total) || isNaN(goal) || Number(goal) === 0) return 'N/A';
  return percentToDecimal((total / goal) * 100);
};

const CalculateScore = ({ Name, School, total, goal }) => (
  <div className="formatstyle">
    <h1 style={{ color: 'brown' }}>Student Details:</h1>
    <div className="Name"> <b>Name:</b> <span>{Name}</span> </div>
    <div className="School"> <b>School:</b> <span>{School}</span> </div>
    <div className="Total"> <b>Total:</b> <span>{total} Marks</span> </div>
    <div className="Score">
      <b>Score:</b>
      <span> {calcScore(total, goal)} </span>
    </div>
  </div>
);

export default CalculateScore;